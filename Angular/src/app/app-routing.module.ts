import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'products', loadChildren: () => import('./pages/product/product.module').then(m => m.ProductModule) },
  { path: '**', redirectTo: '/products', pathMatch: 'full' },
];
const isIframe = window !== window.parent && !window.opener;
@NgModule({
  imports: [RouterModule.forRoot(routes,{
    initialNavigation: !isIframe ? 'enabled' : 'disabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
