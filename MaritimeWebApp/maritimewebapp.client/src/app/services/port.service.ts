import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Port } from '../models/port.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PortService {
  private apiUrl = '/api/ports';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Port[]> {
    return this.http.get<Port[]>(this.apiUrl);
  }
}
