/*
 * buffers.h
 *
 *  Created on: 23 may. 2017
 *      Author: IbonZalbide
 */

#ifndef TOOLS_BUFFERS_H_
#define TOOLS_BUFFERS_H_

#include "../definitions/typedefs.h"

void AppendFloat(uint8_t *buf, uint16_t *i, float data);
void AppendInt16(uint8_t *buf, uint16_t *i, int16_t data);
void AppendInt32(uint8_t *buf, uint16_t *i, int32_t data);

#endif /* TOOLS_BUFFERS_H_ */
