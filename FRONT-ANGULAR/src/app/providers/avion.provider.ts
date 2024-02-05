import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Avion } from "../interfaces/Avion";
import { Observable, catchError, throwError } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AvionProvider{
    constructor(private http : HttpClient){
    }

    CrearAvion(mat: string, mod: string, cant: number, aut: number, fab: string): Observable<any>{
        const request = {
            matricula: mat,
            modelo: mod,
            cantidadPasajeros: cant,
            autonomiaKm: aut,
            idFabricante: fab
        };
        const url : string = 'https://localhost:7274/' + 'Aviones/Create';
        const header = { 'content-type': 'application/json'}    
        console.log(request);    
        return this.http.post<Avion>(url,request, { 'headers': header }).pipe(catchError(this.handleError));
    }

    GetAviones(): Observable<Avion[]>{        
        const url : string = 'https://localhost:7274/' + 'Aviones/Get';       
        return this.http.get<Avion[]>(url).pipe(catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse){
        return throwError(() => new Error(error.error));
    }
}