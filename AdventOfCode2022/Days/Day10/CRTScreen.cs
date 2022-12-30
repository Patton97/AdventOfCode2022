using System;

namespace AdventOfCode2022.Days.Day10;

internal class CRTScreen
{
    private const int SCREEN_WIDTH = 40;
    private const int SCREEN_HEIGHT = 6;
    private const int SPRITE_WIDTH = 3;
    internal CPU CPU
    {
        get => this.cpu;
        set
        {
            if (this.cpu != null)
            {
                this.cpu.CycleCompleted -= this.OnCPUCycleCompleted;
            }
            this.cpu = value;
            this.cpu.CycleCompleted += this.OnCPUCycleCompleted;
        }
    }
    private CPU cpu;

    private char[,] pixelGrid = new char[SCREEN_HEIGHT, SCREEN_WIDTH];

    internal void PrintGrid(Action<char> print)
    {
        for (int rowIndex = 0; rowIndex < this.pixelGrid.GetLength(0); ++rowIndex)
        {
            for (int columnIndex = 0; columnIndex < this.pixelGrid.GetLength(1); ++columnIndex)
            {
                print?.Invoke(this.pixelGrid[rowIndex, columnIndex]);
            }
            print?.Invoke('\n');
        }
        print?.Invoke('\n');
    }

    private void OnCPUCycleCompleted(CPU cpu, CPU.CycleCompletedEventArgs args)
    {
        this.DrawPixel(cpu);
    }

    private void DrawPixel(CPU cpu)
    {
        Vector2Int targetPixelLocation = this.CycleNumberToPixelLocation(cpu.CycleCounter);
        int registerValue = cpu.Registers['X'].Value;
        char pixelToDraw = this.IsSpriteOverTargetPixel(registerValue, targetPixelLocation.X)
            ? '#'
            : '.';

        this.pixelGrid[targetPixelLocation.Y, targetPixelLocation.X] = pixelToDraw;
    }

    private bool IsSpriteOverTargetPixel(int spriteColumnIndex, int targetPixelColumnIndex)
    {
        int spriteStart = spriteColumnIndex - (SPRITE_WIDTH / 2);
        int spriteEnd = spriteColumnIndex + (SPRITE_WIDTH / 2);
        return spriteStart <= targetPixelColumnIndex
            && targetPixelColumnIndex <= spriteEnd;
    }

    private Vector2Int CycleNumberToPixelLocation(uint cycleNumber)
    {
        int pixelIndex = (int)cycleNumber - 1;
        var pixelLocation = new Vector2Int();
        pixelLocation.X = pixelIndex % this.pixelGrid.GetLength(1);
        pixelLocation.Y = pixelIndex / this.pixelGrid.GetLength(1);
        return pixelLocation;
    }
}
