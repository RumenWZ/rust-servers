import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServerService {
  baseUrl = 'https://localhost:7067/api';

  constructor(
    private http: HttpClient
  ) { }

  getServers() {
    return this.http.get(`${this.baseUrl}/server`);
  }
}
