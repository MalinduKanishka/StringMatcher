import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ICompare } from '../interfaces/icompare';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StringMatchService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  public post(compare: ICompare): Observable<ICompare>{



    return this.http.post<ICompare>(this.baseUrl + 'stringmatch', compare);
  }
}
