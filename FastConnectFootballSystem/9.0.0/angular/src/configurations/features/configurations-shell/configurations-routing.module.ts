import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { ConfigurationsPage } from './configurations.page';
import {ConfigurationsFieldsPage} from '../configurations-fields/configurations-fields.page';

const routes = RouterModule.forChild([
    {
      path: '',
      component: ConfigurationsPage,
      canActivate: [AppRouteGuard],
      //data: { permission: "Pages.Configurations" },
      children: [
        { path: '', redirectTo: 'fields', pathMatch: 'full' },
        {
          path: 'fields',
          component: ConfigurationsFieldsPage,
        },
      ],
    },
  ]);
  
  @NgModule({
    imports: [routes],
    exports: [RouterModule],
  })
  export class ConfigurationsRoutingModule {}
  