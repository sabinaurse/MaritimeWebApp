// This file allows you to configure ESLint according to your project's needs, so that you
// can control the strictness of the linter, the plugins to use, and more.

// For more information about configuring ESLint, visit https://eslint.org/docs/user-guide/configuring/

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Ship } from '../models/ship.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShipService {
  private apiUrl = '/api/ships'; // rutele din backendul tău .NET

  constructor(private http: HttpClient) { }

  getAll(): Observable<Ship[]> {
    return this.http.get<Ship[]>(this.apiUrl);
  }

  getById(id: number): Observable<Ship> {
    return this.http.get<Ship>(`${this.apiUrl}/${id}`);
  }

  add(ship: Ship): Observable<Ship> {
    return this.http.post<Ship>(this.apiUrl, ship);
  }

  update(id: number, ship: Ship): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, ship);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
