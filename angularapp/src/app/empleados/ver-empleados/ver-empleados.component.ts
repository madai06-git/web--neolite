import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-ver-empleados',
  templateUrl: './ver-empleados.component.html',
  styleUrls: ['./ver-empleados.component.css']
})
export class VerEmpleadosComponent {
  empleados!: any[];
  constructor(private http: HttpClient)
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
