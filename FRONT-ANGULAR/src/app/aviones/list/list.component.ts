import { Component, OnInit } from '@angular/core';
import { Avion } from 'src/app/interfaces/Avion';
import { AvionProvider } from 'src/app/providers/avion.provider';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  aviones: Avion[] = [];

  constructor(private avionProvider: AvionProvider) { }

  ngOnInit(): void {
    this.avionProvider.GetAviones().subscribe({
      next: (listado: Avion[]) => this.aviones = listado,
      error: (error) => alert(error)
    });
  }
}
