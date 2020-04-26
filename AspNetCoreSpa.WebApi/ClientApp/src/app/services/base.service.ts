import { Injectable } from '@angular/core';
import { Base } from '../models/base';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T extends Base> {
  protected _httpClient: HttpClient = null;
  protected _url: string = null;
  protected _endpoint: string = null;

  protected constructor(
    httpClient: HttpClient,
    url: string,
    endpoint: string
  ) 
  {
    this._httpClient = httpClient;
    this._url = url;
    this._endpoint = endpoint;
  }

  protected httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  
  get(): Observable<T[]> {
    return this._httpClient.get<T[]>(`${this._url}/${this._endpoint}`);
  }

  getById(id: number): Observable<T> {
    return this._httpClient.get<T>(`${this._url}/${this._endpoint}/${id}`);
  }

  create(item: T): Observable<T> {
    return this._httpClient.post<T>(`${this._url}/${this._endpoint}`, JSON.stringify(item), this.httpOptions);
  }

  update(item: T): Observable<T> {
    return this._httpClient.put<T>(`${this._url}/${this._endpoint}/${item.id}`, JSON.stringify(item), this.httpOptions);
  }  
  
  delete(item: T) {
    return this._httpClient.delete<T>(`${this._url}/${this._endpoint}/${item.id}`, this.httpOptions);
  }  
}