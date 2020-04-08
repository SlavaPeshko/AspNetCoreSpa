import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  
  constructor(private httpClient: HttpClient) {
  }

  uploadUserImage(file: FormData, url: string) {
      return this.httpClient.post(url, file);
  }
}