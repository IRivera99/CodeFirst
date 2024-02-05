import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { UsuarioProvider } from "../providers/usuario.provider";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class UserLoggedGuard implements CanActivate{
    constructor(private usuarioProvider: UsuarioProvider, private router: Router){}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        if(!this.usuarioProvider.IsLogged()){
            return this.router.navigate(['/login']).then(() => false);
        }
        return true;
    }
}