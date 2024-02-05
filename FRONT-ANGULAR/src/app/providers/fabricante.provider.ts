import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { Fabricante } from "../interfaces/Fabricante";

@Injectable({
    providedIn: "root"
})
export class FabricanteProvider{
    constructor(private http: HttpClient){}

    GetFabricantes(): Observable<Fabricante[]>{
        const url: string = 'https://localhost:7274/' + 'Fabricantes/Get';
        return this.http.get<Fabricante[]>(url).pipe(catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse){
        return throwError(() => new Error(error.error));
    }
}