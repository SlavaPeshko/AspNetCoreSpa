import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { config } from '../config';
import { Observable } from 'rxjs';
import { Like } from '../models/like';

@Injectable({
  providedIn: 'root'
})
export class LikeService extends BaseService<Like> {
  
  constructor(HttpClient: HttpClient) {
    super(
      HttpClient,
      config.apiUrl,
      config.endpoint.posts.route);
  }

  public createLike(postId: number, isLike: boolean): Observable<number> {

    const url = `${this.Url}/${config.endpoint.likes.create}`;

    return this.HttpClient.post<number>(url, { postId, isLike }, this.httpOptions);
  }

  public deleteLike(id: number) {
    
    const url = `${this.Url}/${config.endpoint.likes.delete(id)}`;
    
    return this.HttpClient.delete(url);
  }
}
