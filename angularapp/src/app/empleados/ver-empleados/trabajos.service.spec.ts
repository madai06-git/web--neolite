import { TestBed } from '@angular/core/testing';

import { TrabajosService } from 'src/app/services/trabajos.service';

describe('TrabajosService', () => {
  let service: TrabajosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrabajosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
