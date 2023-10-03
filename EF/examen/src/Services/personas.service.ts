import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { delay, map, retry } from 'rxjs/operators';
import { CatalogoPersona } from 'src/Models/persona-model';
import { HttpErrorResponse } from '@angular/common/http';
import { environment} from '../environment/enviroment';



@Injectable({
    providedIn: 'root'
  })

  export class PersonaService {
    

    constructor(private http: HttpClient) {
    }
    listPersonaGet : CatalogoPersona[] = [];
    
     getPersona() : Observable<any>{
        
      return this.http.get<CatalogoPersona[]>(environment.apiPersona +'/obtenerPersona');
    }

    addPersona( persona : CatalogoPersona): Observable<any>{
        return this.http.post<CatalogoPersona[]>(  environment.apiPersona +  '/agregarPersona', persona);
      }

     updatePersona( persona : CatalogoPersona): Observable<any>{
        return this.http.put<CatalogoPersona[]>(environment.apiPersona + '/actualizarPersona', persona);
      }

      deletePersona( idPersona : Number): Observable<any>{

        console.log("idPersona")
        console.log(idPersona)
        return this.http.delete<CatalogoPersona[]>(environment.apiPersona + '/eliminarPersona?idPersona='+ idPersona );
      }
  }