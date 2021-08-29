import { TestBed } from '@angular/core/testing';

import { StringMatchService } from './string-match.service';

describe('StringMatchService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StringMatchService = TestBed.get(StringMatchService);
    expect(service).toBeTruthy();
  });
});
