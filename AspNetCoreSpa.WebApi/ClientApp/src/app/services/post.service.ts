import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Post } from '../models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService<Post> {
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient,
      config.apiUrl,
      config.endpoint.post);
  }
}
