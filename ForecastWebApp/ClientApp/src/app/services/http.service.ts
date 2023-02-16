import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  getRequest<T>(url: string, params: HttpParams): Observable<T> {
    return this.httpClient.get<T>(this.createUrl(url), { params });
  }

  private createUrl(url: string): string {
    return environment.apiUrl + url;
  }
}

