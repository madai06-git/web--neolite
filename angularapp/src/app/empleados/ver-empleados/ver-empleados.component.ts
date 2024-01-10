import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-ver-empleados',
  templateUrl: './ver-empleados.component.html',
  styleUrls: ['./ver-empleados.component.css']
})
export class VerEmpleadosComponent {
  empleados!: any[];
  constructor(private http: HttpClient, private router: Router)

  {
    this.getEmpleados();
  }

  getEmpleados() {
    const api: string = 'https://localhost:7216/api/Empleadoes';
    this.http.get<any[]>(api).subscribe((ultimos: any[]) => {
      this.empleados = ultimos;
      console.log('emp', ultimos);
    });

  }
  buscarTrabajosRealizados() {

    console.log('Buscar Trabajos Realizados');
  }

  registrarTrabajo() {
    // Lógica para registrar trabajo
    console.log('Registrar Trabajo');

    // Redirigir a la ventana con tres opciones de botones
    this.router.navigate(['/opciones-trabajo']);
  }
  /*postEmpleados(nuevoEmpleado: any) {
    const api: string = 'https://localhost:7216/api/Empleadoes';
    const headers = new HttpHeaders({ 'Cont-Type': 'application/json' });

    this.http.post<any>(api, nuevoEmpleado, { headers }).subscribe((response: any) => {
      console.log('Empleado agregado:', response);

      // Después de agregar el empleado, actualiza la lista de empleados
      this.getEmpleados();
    });

  }*/

}
