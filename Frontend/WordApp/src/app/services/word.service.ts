import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddWordCommandRequest } from '../models/commands/add/addWordCommandRequest';
import { DeleteWordCommandRequest } from '../models/commands/delete/deleteWordCommandRequest';
import { UpdateWordToKnownCommandRequest } from '../models/commands/update/updateWordToKnownCommandRequest';
import { UpdateWordCheckedTimeCommandRequest } from '../models/commands/update/updateWordCheckedTimeCommandRequest';
import { GetAllDailyWordsQueryResponse } from '../models/queries/getall/daily/getAllDailyWordsQueryResponse';
import { GetAllKnownWordsQueryResponse } from '../models/queries/getall/known/getAllKnownWordsQueryResponse';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WordService {
  apiUrl:string = 'http://localhost:5000/api/Words';
  constructor(private http:HttpClient ) { }

  Add(request:AddWordCommandRequest):Observable<any> {
    let url = this.apiUrl + '/Add';
    return this.http.post(url, request);
  }

  Delete(request:DeleteWordCommandRequest):Observable<any> {
    let url = this.apiUrl + '/Delete?id=' + request.id;
    return this.http.delete(url);
  }

  UpdateToKnown(request:UpdateWordToKnownCommandRequest):Observable<any> {
    let url = this.apiUrl + '/UpdateWordToKnown?id=' + request.id;
    return this.http.put(url, null);
  }

  UpdateChecked(request:UpdateWordCheckedTimeCommandRequest):Observable<any> {
    let url = this.apiUrl + '/UpdateWordChecked?id=' + request.id;
    return this.http.put(url,null);
  }

  GetAllDailyWords():Observable<GetAllDailyWordsQueryResponse[]> {
    let url = this.apiUrl + '/GetAllDailyWords';
    return this.http.get<GetAllDailyWordsQueryResponse[]>(url);
  }


  GetAllKnownWords():Observable<GetAllKnownWordsQueryResponse[]> {
    let url = this.apiUrl + '/GetAllKnownWords';
    return this.http.get<GetAllKnownWordsQueryResponse[]>(url);
  } 
}
