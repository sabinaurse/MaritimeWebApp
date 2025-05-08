import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Voyage } from '../models/voyage.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class VoyageService {
  private apiUrl = '/api/voyages';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Voyage[]> {
    return this.http.get<Voyage[]>(this.apiUrl);
  }
}

