import { MatButtonModule } from '@angular/material';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatBadgeModule } from '@angular/material/badge';
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


@NgModule({
    imports: [MatButtonModule, MatToolbarModule, MatIconModule, MatMenuModule, MatSidenavModule, MatBadgeModule, MatDividerModule, MatCardModule, MatGridListModule, MatFormFieldModule, MatProgressSpinnerModule],
    exports: [MatButtonModule, MatToolbarModule, MatIconModule, MatMenuModule, MatSidenavModule, MatBadgeModule, MatDividerModule, MatCardModule, MatGridListModule, MatFormFieldModule, MatProgressSpinnerModule]
})
export class MaterialModule {
}
