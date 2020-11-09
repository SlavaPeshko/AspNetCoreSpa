import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { config } from "../config";
import { User } from "../models/user";
import { httpOptions } from "../shared/http-options";

@Injectable({
  providedIn: "root",
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  create(body: any) {
    return this.httpClient.post(
      `${config.apiUrl}/${config.endpoint.user.create}`,
      JSON.stringify(body),
      httpOptions
    );
  }

  update(body: User) {
    return this.httpClient.put(
      `${config.apiUrl}/${config.endpoint.user.update}`,
      JSON.stringify(body),
      httpOptions
    );
  }

  changeEmail(id: number, oldEmail: string, newEmail: string) {
    const body = JSON.stringify({ oldEmail, newEmail });
    return this.httpClient.put(
      `${config.apiUrl}/${config.endpoint.user.changeEmail(id)}`,
      body,
      httpOptions
    );
  }

  getById(id: number) {
    return this.httpClient.get<User>(
      `${config.apiUrl}/${config.endpoint.user.get(id)}`
    );
  }

  sendEmail(email: string) {
    return this.httpClient.get(
      `${config.apiUrl}/${config.endpoint.user.sendEmail(email)}`
    );
  }

  validateToken(token: string) {
    return this.httpClient.get(
      `${config.apiUrl}/${config.endpoint.user.validateToken(token)}`
    );
  }

  forgotPassword(model: any) {
    return this.httpClient.post(
      `${config.apiUrl}/${config.endpoint.user.forgotPassword}`,
      JSON.stringify(model),
      httpOptions
    );
  }
}
