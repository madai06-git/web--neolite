import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClienteVentaComponent } from './cliente-venta.component';

describe('ClienteVentaComponent', () => {
  let component: ClienteVentaComponent;
  let fixture: ComponentFixture<ClienteVentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClienteVentaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ClienteVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
