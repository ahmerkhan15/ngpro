import { NgModule } from '@angular/core';
import { DataViewModule } from 'primeng/dataview';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { CodeHighlighterModule } from 'primeng/codehighlighter';
import { CommonModule } from '@angular/common';
import { DataTableModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { CardModule } from 'primeng/card'

@NgModule({
    imports: [DataViewModule,
        PanelModule,
        DialogModule,
        TabViewModule,
        CodeHighlighterModule, DataTableModule, TableModule, ButtonModule, DropdownModule, CardModule],
    exports: [DataViewModule, DataViewModule,
        PanelModule,
        DialogModule,
        TabViewModule,
        CodeHighlighterModule, DataTableModule, TableModule, ButtonModule, DropdownModule, CardModule]
})
export class ngPrimeModule {

}
