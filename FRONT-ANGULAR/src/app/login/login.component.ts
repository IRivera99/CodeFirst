import { Component, OnInit } from '@angular/core';
import { UsuarioProvider } from '../providers/usuario.provider';
import { Usuario } from '../interfaces/Usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {  
  inputUsuario: string = '';
  inputPassword: string = '';

  constructor(private usuarioProvider: UsuarioProvider, 
    private router: Router) { }

  ngOnInit(): void {
  }

  IniciarSesion(){
    this.usuarioProvider.Login(this.inputUsuario, this.inputPassword).subscribe({
      next: (response: Usuario) => this.HandleSuccess(response, this.inputPassword),
      error: (error) => alert(error)
    });      
  }

  HandleSuccess(usuario: Usuario, pass: string){
    alert("Hola " + usuario.nombreUsuario + "!");
    this.usuarioProvider.SetUsuarioLogged(usuario, pass);    
    this.router.navigateByUrl('/home');    
  }

}
