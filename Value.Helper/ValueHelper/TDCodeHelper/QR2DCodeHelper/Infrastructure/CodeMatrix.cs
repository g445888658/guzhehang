using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ValueHelper.TDCodeHelper.BasicStruct;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper.Infrastructure
{
    public class CodeMatrix
    {
        private Int32 specification;
        private SByte[][] matrix;
        private Color[] colors;

        private Point[] pdgPos;
        private Point[] npgPos;

        public CodeMatrix(Int32 specification)
        {
            this.specification = specification;
            matrix = new SByte[specification][];
            colors = new Color[] { Color.White, Color.Black };
            InitMatrix();
        }

        private void InitMatrix()
        {
            for (int i = 0; i < specification; i++)
            {
                matrix[i] = new SByte[specification];
                for (int j = 0; j < specification; j++)
                {
                    //matrix[i][j] = -1;
                }
            }

            fillPDG();
            fillNPG();
        }

        private void fillPDG()
        {
            pdgPos = new Point[] {
                new Point(0, 0),
                new Point(0, specification - ProperStruct.PDG.Length),
                new Point(specification - ProperStruct.PDG.Length, 0) 
            };

            for (int j = 0; j < pdgPos.Length; j++)
            {
                for (int i = 0; i < ProperStruct.PDG.Length; i++)
                {
                    Buffer.BlockCopy(ProperStruct.PDG[i], 0, matrix[pdgPos[j].X + i], pdgPos[j].Y, ProperStruct.PDG.Length);
                }
            }
        }

        private void fillNPG()
        {
            npgPos = new Point[] {
                new Point(ProperStruct.PDG.Length - 1, ProperStruct.PDG.Length + 1),
                new Point(ProperStruct.PDG.Length + 1, ProperStruct.PDG.Length - 1)
            };

            for (int i = 0; i < specification - (ProperStruct.PDG.Length + 1) * 2; i++)
            {
                matrix[npgPos[0].X][npgPos[0].Y + i] = ProperStruct.NPG[i % 2];
                matrix[npgPos[1].X + i][npgPos[1].Y] = ProperStruct.NPG[i % 2];
            }
        }

        public void FillData(SByte[] data)
        {
            var end = false;

            //for (int i = 0; i < data.Length; i += 2)
            //{

            //}
        }

        public Bitmap ConvertToBitmap()
        {
            Bitmap bitmap = new Bitmap(specification, specification);
            for (int vertX = 0; vertX < specification; vertX++)
            {
                for (int vertY = 0; vertY < specification; vertY++)
                {
                    bitmap.SetPixel(vertX, vertY, colors[matrix[vertX][vertY]]);
                }
            }
            return bitmap;
        }
    }
}
