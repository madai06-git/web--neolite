import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventarioMaterialesComponent } from './inventario-materiales.component';

describe('InventarioMaterialesComponent', () => {
  let component: InventarioMaterialesComponent;
  let fixture: ComponentFixture<InventarioMaterialesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InventarioMaterialesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InventarioMaterialesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
