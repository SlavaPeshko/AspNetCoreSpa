import { Injectable } from '@angular/core';
import { JwtHelperService  } from "@auth0/angular-jwt";

@Injectable({
    providedIn: 'root'
  })
export class Jwt {
    
    constructor(private jwtHelper: JwtHelperService) {
      }

    getUserId(): number {
        const token: string = localStorage.getItem("jwt");
        if(token){
            return this.jwtHelper.decodeToken(token).Id;
        }

        return -1;
      }

      getEmail(): string {
        const token: string = localStorage.getItem("jwt");
        if(token){
          return this.jwtHelper.decodeToken(token).Email;
        }

        return null;
      }
}