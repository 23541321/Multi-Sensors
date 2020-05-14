/*
 * buffers.c
 *
 *  Created on: 23 may. 2017
 *      Author: IbonZalbide
 */

#include <msp430.h>
#include "../definitions/typedefs.h"

void AppendFloat(uint8_t *buf, uint16_t *i, float data)
{
    uint8_t *pFloat = (uint8_t*) &data;
    buf[(*i)++] = *(pFloat++);
    buf[(*i)++] = *(pFloat++);
    buf[(*i)++] = *(pFloat++);
    buf[(*i)++] = *(pFloat++);
}

void AppendInt16(uint8_t *buf, uint16_t *i, int16_t data)
{
    uint8_t *pInt16 = (uint8_t*) &data;
    buf[(*i)++] = *(pInt16++);
    buf[(*i)++] = *(pInt16++);
}

void AppendInt32(uint8_t *buf, uint16_t *i, int32_t data)
{
    uint8_t *pInt32 = (uint8_t*) &data;
    buf[(*i)++] = *(pInt32++);
    buf[(*i)++] = *(pInt32++);
    buf[(*i)++] = *(pInt32++);
    buf[(*i)++] = *(pInt32++);
}
