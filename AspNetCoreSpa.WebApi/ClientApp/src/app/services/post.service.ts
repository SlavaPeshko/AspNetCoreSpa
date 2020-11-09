import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Observable } from 'rxjs';
import { Post } from '../models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService<any> {
  
  constructor(HttpClient: HttpClient) {
    super(
      HttpClient,
      config.apiUrl,
      config.endpoint.posts.route);
  }

  public getByPageItems(page: number, items: number): Observable<Post[]> {
    
    return this.HttpClient.get<Post[]>(`${this.Url}/${this.Endpoint}/${page}/${items}`);
  }

  public getRating(postId: number): Observable<number> {

    return this.HttpClient.get<number>(`${this.Url}/${config.endpoint.posts.getRating(postId)}`);
  }
}
