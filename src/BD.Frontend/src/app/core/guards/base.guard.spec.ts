import { TestBed } from '@angular/core/testing';

import { BaseGuard } from './base.guard';

describe('BaseGuard', () => {
  let guard: BaseGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(BaseGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
