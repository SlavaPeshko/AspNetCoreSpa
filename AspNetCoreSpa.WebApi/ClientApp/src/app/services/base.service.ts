import { Injectable } from '@angular/core';
import { Base } from '../models/base';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService<T extends Base> {
  protected HttpClient: HttpClient = null;
  protected Url: string = null;
  protected Endpoint: string = null;

  protected constructor(
    httpClient: HttpClient,
    url: string,
    endpoint: string
  ) 
  {
    this.HttpClient = httpClient;
    this.Url = url;
    this.Endpoint = endpoint;
  }

  protected httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  
  get(): Observable<T[]> {
    return this.HttpClient.get<T[]>(`${this.Url}/${this.Endpoint}`);
  }

  getById(id: number): Observable<T> {
    return this.HttpClient.get<T>(`${this.Url}/${this.Endpoint}/${id}`);
  }

  create(item: T): Observable<T> {
    return this.HttpClient.post<T>(`${this.Url}/${this.Endpoint}`, JSON.stringify(item), this.httpOptions);
  }

  update(item: T): Observable<T> {
    return this.HttpClient.put<T>(`${this.Url}/${this.Endpoint}/${item.id}`, JSON.stringify(item), this.httpOptions);
  }  
  
  delete(item: T) {
    return this.HttpClient.delete<T>(`${this.Url}/${this.Endpoint}/${item.id}`, this.httpOptions);
  }  
}