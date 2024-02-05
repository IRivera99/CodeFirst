import { Component, OnChanges } from '@angular/core';
import { UsuarioProvider } from './providers/usuario.provider';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

  constructor(private usuarioProvider: UsuarioProvider){
  }  

  CheckSession(): boolean{
    return this.usuarioProvider.IsLogged();
  }

  CerrarSesion(){
    let nombre = sessionStorage.getItem("user");
    let pass = sessionStorage.getItem("pass");
    if(nombre != null && pass != null){
      this.usuarioProvider.Logout(nombre, pass).subscribe({
        next: () => this.usuarioProvider.SetUsuarioLogout(),
        error: (error) => alert(error)
      });      
    }
  }
}
