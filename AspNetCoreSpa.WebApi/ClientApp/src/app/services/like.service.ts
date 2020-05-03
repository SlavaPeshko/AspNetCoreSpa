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
  
  constructor(httpClient: HttpClient) {
    super(
      httpClient,
      config.apiUrl,
      config.endpoint.posts.route);
  }

  public createLike(postId: number, isLike: boolean): Observable<number> {

    const url = `${this._url}/${config.endpoint.likes.create}`;

    return this._httpClient.post<number>(url, { postId, isLike }, this.httpOptions);
  }

  public deleteLike(id: number) {
    
    const url = `${this._url}/${config.endpoint.likes.delete(id)}`;
    
    return this._httpClient.delete(url);
  }
}
