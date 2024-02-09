import { Component, OnInit } from '@angular/core';
//import { Trabajo } from './trabajo.model';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { TrabajosService } from 'src/app/services/trabajos.service';

@Component({
  selector: 'app-ver-empleados',
  templateUrl: './ver-empleados.component.html',
  styleUrls: ['./ver-empleados.component.css']
})
export class VerEmpleadosComponent{
  empleados: any[] = [];
  trabajosRealizados: any[] = [];
  //trabajosService !: any;
  constructor(
    private http: HttpClient,
    private router: Router,
    private TrabajosService: TrabajosService)

  {
  }
  ngOnInit(): void {
    this.getEmpleados();
  }


  getEmpleados() {
    const api: string = 'https://localhost:7216/api/Empleadoes';
    this.http.get<any[]>(api).subscribe((ultimos: any[]) => {
      this.empleados = ultimos;
      console.log('emp', ultimos);
    });

  }
  /*buscarTrabajosRealizados(empleadoId: number): void {

    this.TrabajosService.obtenerTrabajosRealizados(empleadoId).subscribe(
      trabajos => {
        this.trabajosRealizados = trabajos;
      },
      error => {
        console.error('Error al obtener los trabajos realizados:', error);
      }
    )

   // console.log('Buscar Trabajos Realizados');
  }*/


  registrarTrabajo(empleadoId: number) {
    this.router.navigate(['/opciones-trabajo']);

   /* this.trabajosService.registrarTrabajo(empleadoId).subscribe(() => {
      console.log('Trabajo registrado exitosamente.', empleadoId);
    }, (error: HttpErrorResponse) => {
      console.error('Error al registrar el trabajo:', error);
    });*/
  }
}
