using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_CW
{
    class Grammar
    {
        // MOV - присвоить
        // JCC - условный переход
        // JMP - безусловный переход
        // ADD - сложение
        // MUL - умножение
        // label - метка


        public static string LL1 = @"

<program> ::= <operator> <program> >>> if for <ID>[1]

<program> ::=  >>> end endif else EOF

<operator> ::= <assign_operator> >>> <ID>[1]

<operator> ::= <cond_operator> >>> if

<operator> ::= <loop_operator> >>> for

<assign_operator> ::= <ID>[1] = <E>[2] {MOV}[1,2] ; >>> <ID>[1]

<cond_operator> ::= if ( <logical_expression>[1] ) {JCC}[2,1] <program> <else>[2] endif >>> if

<else>[1] ::= {JMP}[2] else {label}[1] <program> {label}[2] >>> else

<else>[1] ::= {label}[1]  >>> if for <ID>[1] end endif EOF

<loop_operator> ::= for ( <assign_operator> {label}[7] <logical_expression>[3] {JCC}[8,3] {JMP}[5] ; {label}[6] <assign_operator> {JMP}[7] ) {label}[5] <program> {JMP}[6]  end {label}[8] >>> for

<E>[1]  ::= <T>[2] <E_list>[2,1] >>> <ID>[1] <INT>[1]

<E_list>[1,2] ::= + <T>[3] {ADD}[1,3,4] <E_list>[4,2] >>> +

<E_list>[1,1] ::=  >>> ;

<T>[1]  ::= <F>[2] <T_list>[2,1] >>> <ID> <INT>

<T_list>[1,2] ::= * <F>[3] {MUL}[1,3,4] <T_list>[4,2]  >>> *

<T_list>[1,1] ::=   >>> + ;

<F>[1]  ::= <ID>[1]   >>> <ID>

<F>[1] ::= <INT>[1]  >>> <INT>

<logical_expression>[1] ::= <F>[2] <R_list>[2,1]  >>> <ID> <INT>

<R_list>[1,2] ::= > <F>[3] {>}[1,3,2] >>> >

<R_list>[1,2] ::= < <F>[3] {<}[1,3,2] >>> <

";

    }
}
