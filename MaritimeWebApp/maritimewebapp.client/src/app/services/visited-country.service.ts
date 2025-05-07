import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VisitedCountry } from '../models/visited-country.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class VisitedCountryService {
  private apiUrl = '/api/visitedcountries';

  constructor(private http: HttpClient) { }

  getAll(): Observable<VisitedCountry[]> {
    return this.http.get<VisitedCountry[]>(this.apiUrl);
  }
}
