import { Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ErrorPageComponent } from './pages/error-page/error-page.component';

export const routes: Routes = [
    {path: '', component:HomePageComponent, },
    {path: '**',redirectTo:'', component:ErrorPageComponent, }
];
