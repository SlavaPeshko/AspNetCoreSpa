import {
    HttpEvent,
    HttpHandler,
    HttpRequest,
    HttpErrorResponse,
    HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ToastrService } from "ngx-toastr";

@Injectable()
export class ErrorIntercept implements HttpInterceptor {

    constructor(public toasterService: ToastrService) {}

    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(
                retry(0),
                catchError((error: HttpErrorResponse) => {
                    let errorMessage = '';
                    if (error.error instanceof Array && error.error.length > 0) {
                        this.toasterService.error(`${error.error[0].description}`, 'Error');
                    } else {
                        errorMessage = `Error Status: ${error.status}\nMessage: ${error.message}`;
                    }
                    return throwError(errorMessage);
                })
            )
    }
}