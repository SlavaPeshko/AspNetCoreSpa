import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { config } from '../config';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  
  constructor(private httpClient: HttpClient) {
  }

  uploadImages(file: FormData, url: string) {
      return this.httpClient.post(url, file);
  }

  uploadUserImage(body: any) {
    return this.httpClient.post(`${config.apiUrl}/${config.endpoint.images.uploadUserImage}`, body);
  }
}