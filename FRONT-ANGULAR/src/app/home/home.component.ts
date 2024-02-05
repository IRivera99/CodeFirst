import { Component, OnInit } from '@angular/core';
import { UsuarioProvider } from '../providers/usuario.provider';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private usuarioProvider: UsuarioProvider) { }

  ngOnInit(): void {
  }

  CheckSession(): boolean{
    return this.usuarioProvider.IsLogged();
  }

}
