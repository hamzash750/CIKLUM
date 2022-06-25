import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDetailsComponent } from './product-details.component';

describe('ProductDetailsComponent', () => {
  let component: ProductDetailsComponent;
  let fixture: ComponentFixture<ProductDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    component.product={
      "id": 1,
      "title": "Product 1",
      "price": 123,
      "description": "Test description test",
      "image": "assets/image1.jpg",
      "rating": {
        "rate": 3,
        "count": 3
      }
    };
    expect(component).toBeTruthy();
  });
  it('Calculate Discount', () => {
    component.discount=10;
    expect(component.calculateDiscountInPercentage(100)).toBe(90);
  });
});
