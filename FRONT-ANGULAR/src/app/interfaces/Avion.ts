import { Fabricante } from "./Fabricante"

export interface Avion{
    id: string,
    matricula: string,
    modelo: string,
    cantidadPasajeros: number,
    autonomiaKm: number,
    fechaAlta: Date,
    fabricante: Fabricante    
}