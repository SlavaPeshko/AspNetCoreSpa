import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  
  constructor(private httpClient: HttpClient) {
  }

  uploadImages(file: FormData, url: string) {
      return this.httpClient.post(url, file);
  }
}