import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, throwError } from "rxjs";
import { Usuario } from "../interfaces/Usuario";

@Injectable({
    providedIn: 'root'
})

export class UsuarioProvider{    
    constructor(private http : HttpClient){
    }

    Login(nombre: string, contraseña: string): Observable<any>{
        const request = {
            nombreUsuario : nombre,
            password : contraseña
        };
        const url : string = 'https://localhost:7274/' + 'Usuarios/Login';
        const header = { 'content-type': 'application/json'}        
        return this.http.post<Usuario>(url,request, { 'headers': header }).pipe(catchError(this.handleError));
    }

    Logout(nombre: string, contraseña: string): Observable<any>{
        const request = {
            nombreUsuario : nombre,
            password : contraseña
        };
        const url : string = 'https://localhost:7274/' + 'Usuarios/Logout';
        const header = { 'content-type': 'application/json'}
        return this.http.post<Usuario>(url,request, { 'headers': header }).pipe(catchError(this.handleError));
    }

    SetUsuarioLogged(usuario: Usuario, pass: string){
        sessionStorage.setItem("logged", "true");
        sessionStorage.setItem("user", usuario.nombreUsuario);
        sessionStorage.setItem("pass", pass);        
    }

    SetUsuarioLogout(){
        alert("Sesión finalizada");
        sessionStorage.removeItem("logged");
        sessionStorage.removeItem("user");
        sessionStorage.removeItem("pass");              
    }

    IsLogged(): boolean{
        return sessionStorage.getItem("logged") === "true";
    }

    private handleError(error: HttpErrorResponse){
        return throwError(() => new Error(error.error));
    }
}