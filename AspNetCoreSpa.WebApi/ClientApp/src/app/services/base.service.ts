import { Injectable } from '@angular/core';
import { Base } from '../models/base';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T extends Base> {

  constructor(
    private httpClient: HttpClient,
    private url: string,
    private endpoint: string,
  ) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  
  get(): Observable<T[]> {
    return this.httpClient
      .get<T[]>(`${this.url}/${this.endpoint}`)
      .pipe(catchError(this.handleError))
  }

  getById(id: string): Observable<T> {
    return this.httpClient
      .get<T>(`${this.url}/${this.endpoint}/${id}`)
      .pipe(catchError(this.handleError))
  }

  create(item: T): Observable<T> {
    return this.httpClient.post<T>(`${this.url}/${this.endpoint}`, JSON.stringify(item), this.httpOptions)
      .pipe(catchError(this.handleError))
  }

  update(item: T): Observable<T> {
    return this.httpClient.put<T>(`${this.url}/${this.endpoint}/${item.id}`, JSON.stringify(item), this.httpOptions)
      .pipe(catchError(this.handleError))
  }  
  
  delete(item: T) {
    return this.httpClient.delete<T>(`${this.url}/${this.endpoint}/${item.id}`, this.httpOptions)
      .pipe(catchError(this.handleError))
  }  

  private handleError(error: HttpErrorResponse){
    let errorMessage = '';

    if(error.error instanceof ErrorEvent){
      errorMessage = error.error.message; 
    } else {
      errorMessage = `${error.status}, ${error.message}`;
    }

    return throwError(errorMessage);
  }
}