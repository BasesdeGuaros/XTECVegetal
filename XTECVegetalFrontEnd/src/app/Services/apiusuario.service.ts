import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Reply } from '../Models/reply'
import { estudiante } from '../Models/estudiante'
import { profesor } from '../Models/profesor'

//ng generate service services/apiusuario

const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type': 'appliacation/json'
  })
};


@Injectable({
  providedIn: 'root'
})
export class ApiusuarioService {

  url: string = "https://localhost:5000/api/Usuario"; //SQL
  urlEstudiante: string = "http://localhost:5000/api/estudiantes"; //MongoDB
  urlProfesor: string = "http://localhost:5000/api/profesores"; //MongoDB

  constructor(private _http: HttpClient) { }
  
  getUser(): Observable<Reply> {
    return this._http.get<Reply>(this.url);
  }

  getEstudiante(): Observable<Reply> {
    return this._http.get<Reply>(this.urlEstudiante);
  }

  addEstudiante(usuario: estudiante): Observable<Reply> {
    return this._http.post<Reply>(this.urlEstudiante, usuario, httpOption)
  }

  getProfesor(): Observable<Reply> {
    return this._http.get<Reply>(this.urlProfesor);
  }

  addProfesor(usuario: profesor): Observable<Reply> {
    return this._http.post<Reply>(this.urlProfesor, usuario, httpOption)
  }

  /*
   //request modificado, ver Controller de progra pasada
  getProducer(rol: string): Observable<Reply> {
    return this._http.get<Reply>(this.url+rol);
  }

  edit(user: usuario): Observable<Reply> {
    return this._http.put<Reply>(this.url, user, httpOption)
  }

  //hay que modificarlo o hacer su implementacion 
  delete(userName: string): Observable<Reply> { 
    return this._http.delete<Reply>(`${this.url}/${userName}`)
  }
  */
}
