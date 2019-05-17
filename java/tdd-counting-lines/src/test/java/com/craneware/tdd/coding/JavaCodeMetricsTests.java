package com.craneware.tdd.coding;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class JavaCodeMetricsTests {

    @Test
    public void CountLines_ReturnsZero_WhenEmptyString() {

        int result = JavaCodeMetrics.countLines("");

        assertEquals(0, result);
    }
    @Test
    public void CountLinesReturnsZeroWhenStringIsNull() {
        int expected = 0;
        int result = JavaCodeMetrics.countLines(null);
        assertEquals(expected, result);
    }

    @Test
    public void CountLinesReturnsOneWhenStringIncludesALineOfValidCode(){
        int expected = 1;
        int result = JavaCodeMetrics.countLines("{}");
        assertEquals(expected, result);
    }

    @Test
    public void CountLinesReturnsTwoWhenStringHasTwoLines(){
        int expected = 2;
        int result = JavaCodeMetrics.countLines("One Line \n Another Line ");
        assertEquals(expected, result);
    }

    @Test
    public void CountLines_ReturnsThree_WhenCodeHasThreeNonEmptyLines() {
        int expected = 3;
        int result = JavaCodeMetrics.countLines("One \n Two \n Another Line ");
        assertEquals(expected, result);
    }

    @Test
    public void CountLines_Ignores_ImportStatement() {
        int expected = 0;
        int result = JavaCodeMetrics.countLines("import package.java.com");
        assertEquals(expected, result);
    }
    @Test
    public void CountLines_IgnoreEmptyLines() {
        int expected = 2;
        int result = JavaCodeMetrics.countLines("one \n \n three");
        assertEquals(expected, result);
    }

    @Test
    public void countLines_IgnoresSingleLineComment_WhenNoCodeIsOnLine() {
        int result = JavaCodeMetrics.countLines("one \n \n //three");
        assertEquals(1, result);
    }

    @Test
    public void CountLines_IgnoresPackageStatement() {
        int expected = 1;
        int result = JavaCodeMetrics.countLines("package testPackage \n public static int testFunction()");
        assertEquals(expected, result);
    }

    @Test
    public void CountLines_IgnoresMultiLineComments() {
        int expected = 1;
        int result = JavaCodeMetrics.countLines("One line  \n/*Comment \n Second line of comment*/");
        assertEquals(expected, result);
    }

    @Test
    public void CountLines_IgnoreThreeLineComment() {
        int expected = 1;
        int result = JavaCodeMetrics.countLines("One line \n/*Comment starts \n keeps going \n comment ends*/" );
        assertEquals(expected, result);
    }
}
