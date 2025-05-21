
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_WHITESPACE         =  2, // (Whitespace)
        SYMBOL_MINUS              =  3, // '-'
        SYMBOL_MINUSMINUS         =  4, // --
        SYMBOL_EXCLAMEQ           =  5, // '!='
        SYMBOL_LPARAN             =  6, // '('
        SYMBOL_RPARAN             =  7, // ')'
        SYMBOL_TIMES              =  8, // '*'
        SYMBOL_TIMESTIMES         =  9, // '**'
        SYMBOL_COMMA              = 10, // ','
        SYMBOL_DIV                = 11, // '/'
        SYMBOL_SEMI               = 12, // ';'
        SYMBOL_PLUS               = 13, // '+'
        SYMBOL_PLUSPLUS           = 14, // '++'
        SYMBOL_LT                 = 15, // '<'
        SYMBOL_EQ                 = 16, // '='
        SYMBOL_EQEQ               = 17, // '=='
        SYMBOL_GT                 = 18, // '>'
        SYMBOL_BEGIN              = 19, // begin
        SYMBOL_DIGIT              = 20, // Digit
        SYMBOL_DOUBLE             = 21, // double
        SYMBOL_END                = 22, // end
        SYMBOL_FLOAT              = 23, // float
        SYMBOL_ID                 = 24, // Id
        SYMBOL_IF                 = 25, // if
        SYMBOL_INT                = 26, // int
        SYMBOL_LOOP               = 27, // loop
        SYMBOL_STRING             = 28, // string
        SYMBOL_THEN               = 29, // then
        SYMBOL_VOID               = 30, // void
        SYMBOL_WHILE              = 31, // while
        SYMBOL_ARGUMENT_LIST      = 32, // <argument_list>
        SYMBOL_ASSIGN             = 33, // <assign>
        SYMBOL_CONCEPT            = 34, // <concept>
        SYMBOL_COND               = 35, // <cond>
        SYMBOL_DATA               = 36, // <data>
        SYMBOL_DATA_TYPE          = 37, // <data_type>
        SYMBOL_DIGIT2             = 38, // <digit>
        SYMBOL_EXP                = 39, // <exp>
        SYMBOL_EXPR               = 40, // <expr>
        SYMBOL_FACTOR             = 41, // <factor>
        SYMBOL_FUNCTION_CALL      = 42, // <function_call>
        SYMBOL_FUNCTION_DEF       = 43, // <function_def>
        SYMBOL_FUNCTION_NAME      = 44, // <function_name>
        SYMBOL_ID2                = 45, // <id>
        SYMBOL_IF_STMT            = 46, // <if_stmt>
        SYMBOL_LOOP_STMT          = 47, // <loop_stmt>
        SYMBOL_OP                 = 48, // <op>
        SYMBOL_PARAMETER          = 49, // <parameter>
        SYMBOL_PARAMETER_LIST     = 50, // <parameter_list>
        SYMBOL_PROGRAM            = 51, // <program>
        SYMBOL_RETURN_TYPE        = 52, // <return_type>
        SYMBOL_STATEMENTS         = 53, // <statements>
        SYMBOL_STEP               = 54, // <step>
        SYMBOL_TERM               = 55, // <term>
        SYMBOL_VARIABLE_DECL      = 56, // <variable_decl>
        SYMBOL_VARIABLE_DECL_LIST = 57, // <variable_decl_list>
        SYMBOL_WHILE_STMT         = 58  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_BEGIN_END                                =  0, // <program> ::= begin <statements> end
        RULE_STATEMENTS                                       =  1, // <statements> ::= <concept>
        RULE_STATEMENTS2                                      =  2, // <statements> ::= <concept> <statements>
        RULE_CONCEPT                                          =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                         =  4, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                         =  5, // <concept> ::= <loop_stmt>
        RULE_CONCEPT4                                         =  6, // <concept> ::= <while_stmt>
        RULE_ASSIGN_EQ                                        =  7, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                            =  8, // <id> ::= Id
        RULE_EXPR_PLUS                                        =  9, // <expr> ::= <term> '+' <expr>
        RULE_EXPR_MINUS                                       = 10, // <expr> ::= <term> '-' <expr>
        RULE_EXPR                                             = 11, // <expr> ::= <term>
        RULE_TERM_TIMES                                       = 12, // <term> ::= <factor> '*' <term>
        RULE_TERM_DIV                                         = 13, // <term> ::= <factor> '/' <term>
        RULE_TERM                                             = 14, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                = 15, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                           = 16, // <factor> ::= <exp>
        RULE_EXP_LPARAN_RPARAN                                = 17, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                              = 18, // <exp> ::= <id>
        RULE_EXP2                                             = 19, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                      = 20, // <digit> ::= Digit
        RULE_IF_STMT_IF_LPARAN_RPARAN_THEN_BEGIN_END          = 21, // <if_stmt> ::= if '(' <cond> ')' then begin <statements> end
        RULE_IF_STMT_IF_LPARAN_RPARAN_THEN_BEGIN_END2         = 22, // <if_stmt> ::= if '(' <cond> ')' then begin <statements> end <statements>
        RULE_COND                                             = 23, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                            = 24, // <op> ::= '<'
        RULE_OP_GT                                            = 25, // <op> ::= '>'
        RULE_OP_EQEQ                                          = 26, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                      = 27, // <op> ::= '!='
        RULE_WHILE_STMT_WHILE_LPARAN_RPARAN_BEGIN_END         = 28, // <while_stmt> ::= while '(' <cond> ')' begin <statements> end
        RULE_LOOP_STMT_LOOP_LPARAN_SEMI_SEMI_RPARAN_BEGIN_END = 29, // <loop_stmt> ::= loop '(' <data> <assign> ';' <cond> ';' <step> ')' begin <statements> end
        RULE_DATA_INT                                         = 30, // <data> ::= int
        RULE_DATA_DOUBLE                                      = 31, // <data> ::= double
        RULE_DATA_FLOAT                                       = 32, // <data> ::= float
        RULE_DATA_STRING                                      = 33, // <data> ::= string
        RULE_STEP_MINUSMINUS                                  = 34, // <step> ::= -- <id>
        RULE_STEP_MINUSMINUS2                                 = 35, // <step> ::= <id> --
        RULE_STEP_PLUSPLUS                                    = 36, // <step> ::= <id> '++'
        RULE_STEP_PLUSPLUS2                                   = 37, // <step> ::= '++' <id>
        RULE_STEP                                             = 38, // <step> ::= <assign>
        RULE_VARIABLE_DECL                                    = 39, // <variable_decl> ::= <data_type> <id>
        RULE_DATA_TYPE_INT                                    = 40, // <data_type> ::= int
        RULE_DATA_TYPE_FLOAT                                  = 41, // <data_type> ::= float
        RULE_DATA_TYPE_DOUBLE                                 = 42, // <data_type> ::= double
        RULE_DATA_TYPE_STRING                                 = 43, // <data_type> ::= string
        RULE_FUNCTION_DEF_LPARAN_RPARAN_BEGIN_END             = 44, // <function_def> ::= <return_type> <function_name> '(' <parameter_list> ')' begin <variable_decl_list> <statements> end
        RULE_RETURN_TYPE_INT                                  = 45, // <return_type> ::= int
        RULE_RETURN_TYPE_FLOAT                                = 46, // <return_type> ::= float
        RULE_RETURN_TYPE_DOUBLE                               = 47, // <return_type> ::= double
        RULE_RETURN_TYPE_STRING                               = 48, // <return_type> ::= string
        RULE_RETURN_TYPE_VOID                                 = 49, // <return_type> ::= void
        RULE_FUNCTION_NAME_ID                                 = 50, // <function_name> ::= Id
        RULE_PARAMETER_LIST                                   = 51, // <parameter_list> ::= <parameter>
        RULE_PARAMETER_LIST_COMMA                             = 52, // <parameter_list> ::= <parameter> ',' <parameter_list>
        RULE_PARAMETER                                        = 53, // <parameter> ::= <data_type> <id>
        RULE_VARIABLE_DECL_LIST                               = 54, // <variable_decl_list> ::= <variable_decl>
        RULE_VARIABLE_DECL_LIST2                              = 55, // <variable_decl_list> ::= <variable_decl> <variable_decl_list>
        RULE_FUNCTION_CALL_LPARAN_RPARAN                      = 56, // <function_call> ::= <id> '(' <argument_list> ')'
        RULE_ARGUMENT_LIST                                    = 57, // <argument_list> ::= <expr>
        RULE_ARGUMENT_LIST_COMMA                              = 58  // <argument_list> ::= <expr> ',' <argument_list>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //--
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //loop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENT_LIST :
                //<argument_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA_TYPE :
                //<data_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL :
                //<function_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_DEF :
                //<function_def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_NAME :
                //<function_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP_STMT :
                //<loop_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER_LIST :
                //<parameter_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_TYPE :
                //<return_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTS :
                //<statements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE_DECL :
                //<variable_decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLE_DECL_LIST :
                //<variable_decl_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_BEGIN_END :
                //<program> ::= begin <statements> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS :
                //<statements> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTS2 :
                //<statements> ::= <concept> <statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <loop_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <term> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <term> '-' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <factor> '*' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <factor> '/' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPARAN_RPARAN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPARAN_RPARAN_THEN_BEGIN_END :
                //<if_stmt> ::= if '(' <cond> ')' then begin <statements> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPARAN_RPARAN_THEN_BEGIN_END2 :
                //<if_stmt> ::= if '(' <cond> ')' then begin <statements> end <statements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_WHILE_LPARAN_RPARAN_BEGIN_END :
                //<while_stmt> ::= while '(' <cond> ')' begin <statements> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_STMT_LOOP_LPARAN_SEMI_SEMI_RPARAN_BEGIN_END :
                //<loop_stmt> ::= loop '(' <data> <assign> ';' <cond> ';' <step> ')' begin <statements> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= -- <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> --
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECL :
                //<variable_decl> ::= <data_type> <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_INT :
                //<data_type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_FLOAT :
                //<data_type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_DOUBLE :
                //<data_type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_STRING :
                //<data_type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_DEF_LPARAN_RPARAN_BEGIN_END :
                //<function_def> ::= <return_type> <function_name> '(' <parameter_list> ')' begin <variable_decl_list> <statements> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_INT :
                //<return_type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_FLOAT :
                //<return_type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_DOUBLE :
                //<return_type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_STRING :
                //<return_type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_VOID :
                //<return_type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_NAME_ID :
                //<function_name> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_LIST :
                //<parameter_list> ::= <parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_LIST_COMMA :
                //<parameter_list> ::= <parameter> ',' <parameter_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER :
                //<parameter> ::= <data_type> <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECL_LIST :
                //<variable_decl_list> ::= <variable_decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLE_DECL_LIST2 :
                //<variable_decl_list> ::= <variable_decl> <variable_decl_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_LPARAN_RPARAN :
                //<function_call> ::= <id> '(' <argument_list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_LIST :
                //<argument_list> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_LIST_COMMA :
                //<argument_list> ::= <expr> ',' <argument_list>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
