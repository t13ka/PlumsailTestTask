import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Entity } from 'src/app/models/Entity';
// import { filter, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EntitiesService {
  baseUrl = 'http://localhost:54462/entities';
  httpOptions: any = { headers: new HttpHeaders({ 'Content-type': 'application/json' }) };

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get<Entity[]>(this.baseUrl);
  }

  add(entity: Entity) {
    return this.http.post(this.baseUrl, entity, this.httpOptions);
  }

  find(query: string) {
    const customUrl = `${this.baseUrl}?query=${query}`;
    return this.http.get<Entity[]>(customUrl);
  }
}
