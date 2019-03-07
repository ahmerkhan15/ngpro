import { NgModule } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';
import { DataGridModule } from 'primeng/datagrid';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { CodeHighlighterModule } from 'primeng/codehighlighter';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [DataViewModule,
        DataGridModule,
        PanelModule,
        DialogModule,
        TabViewModule,
        CodeHighlighterModule],
    exports: [DataViewModule]
})
export class ngPrimeModule {

}
