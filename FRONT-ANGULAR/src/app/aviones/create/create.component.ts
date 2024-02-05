import { Component, OnInit } from '@angular/core';
import { Avion } from 'src/app/interfaces/Avion';
import { Fabricante } from 'src/app/interfaces/Fabricante';
import { AvionProvider } from 'src/app/providers/avion.provider';
import { FabricanteProvider } from 'src/app/providers/fabricante.provider';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {  
  fabricantes: Fabricante[] = [];
  matricula: string = "";
  modelo: string = "";
  cantidadPasajeros: number = 0;
  autonomiaKm: number = 0;
  fabricante: string = "";

  
  constructor(private avionProvider: AvionProvider, private fabricanteProvider: FabricanteProvider) {}

  ngOnInit(): void {
    this.fabricanteProvider.GetFabricantes().subscribe({
      next: (listado: Fabricante[]) => this.fabricantes = listado,
      error: (error) => alert(error)
    });
  }

  Agregar(): void{
    this.avionProvider.CrearAvion(this.matricula, this.modelo, this.cantidadPasajeros, this.autonomiaKm, this.fabricante).subscribe({
      next: (response) => console.log(response),
      error: (error) => alert(error)
    });
  }
}
