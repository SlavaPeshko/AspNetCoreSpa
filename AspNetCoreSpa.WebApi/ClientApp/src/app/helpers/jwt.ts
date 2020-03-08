import { Injectable } from '@angular/core';
import { JwtHelperService  } from "@auth0/angular-jwt";
import { AuthService } from '../services/auth.service';

@Injectable({
    providedIn: 'root'
  })
export class Jwt {
    
    constructor(private jwtHelper: JwtHelperService, private auth: AuthService) {
      }

    getUserId() {
        const token: string = localStorage.getItem("jwt");
        if(token){
            return this.jwtHelper.decodeToken(token).Id;
        }

        return null;
      }
}